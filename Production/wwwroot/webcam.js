
// Store references to the video elements on the page
let videoElements = [];
// Store references to active media streams
let streamRefs = [];

/**
 * Starts the cameras and assigns video streams to the specified video elements.
 * @param {string[]} videoIds - An array of video element IDs.
 */
async function startCameras(videoIds) {
    

    // Ensure videoIds is an array
    if (!Array.isArray(videoIds)) {
        console.error("videoIds must be an array.");
        return;
    }
    // Get video elements from the document based on the provided IDs
    videoElements = videoIds.map(id => document.getElementById(id));
    // Get a list of all available media devices
    const devices = await navigator.mediaDevices.enumerateDevices();
    // Filter out only video input devices (cameras)
    const videoDevices = devices.filter(device => device.kind === "videoinput");

    console.log("Available video devices:", videoDevices);
    // Check if enough cameras are available for the requested video elements
    if (videoDevices.length < videoElements.length) {
        console.error("Not enough cameras available.");
        return;
    }
    // Assign each available camera to a corresponding video element
    for (let i = 0; i < videoElements.length; i++) {
        streamRefs[i] = await navigator.mediaDevices.getUserMedia({ video: { deviceId: videoDevices[i].deviceId } });
        // Assign the camera stream to the video element
        videoElements[i].srcObject = streamRefs[i];
    }
    //stopCameras();
}

/**
 * Captures an image from a video element and returns it as a Base64 string.
 * @param {string} videoId - The ID of the video element to capture an image from.
 * @returns {string|null} - Base64 encoded image or null if capture fails.
 */
function captureImage(videoId) {
    let video = document.getElementById(videoId);
    if (!video) return null;

    let canvas = document.createElement("canvas");
    canvas.width = video.videoWidth;
    canvas.height = video.videoHeight;
    let ctx = canvas.getContext("2d");
    ctx.drawImage(video, 0, 0, canvas.width, canvas.height);
    return canvas.toDataURL("image/jpeg");
}

/**
 * Stops all active video streams.
 */
function stopCameras() {
    streamRefs.forEach(stream => stream?.getTracks().forEach(track => track.stop()));
    streamRefs = [];
}

/**
 * Requests permission to access cameras and logs the updated list of available devices.
 */
async function requestCameras() {
    try {
        // Force Chrome to show a camera selection dialog
        await navigator.mediaDevices.getUserMedia({ video: true });

        // Re-list devices after permission is granted
        const devices = await navigator.mediaDevices.enumerateDevices();
        console.log("Updated Cameras:", devices);
    } catch (error) {
        console.error("Camera permission denied:", error);
    }
}