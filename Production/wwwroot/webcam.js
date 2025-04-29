
// Store references to the video elements on the page
let videoElements = [];
// Store references to active media streams
let streamRefs = [];

/**
 * Starts the cameras and assigns video streams to the specified video elements.
 * @param {string[]} videoIds - An array of video element IDs.
 */
async function startCameras(videoIds) {
    
    //TODO remake to check if there are permissions to use camera or check if there are 2 cameras if not ask for permission
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
    if (!video) {
        console.error("🚨 Video element not found:", videoId);
        return "ERROR_NO_VIDEO";
    }


    if (video.readyState < 2) {  // Ensure video has enough data
        console.error("🚨 Video is not ready yet.");
        return "ERROR_VIDEO_NOT_READY";
    }

    console.log("✅ Video found & is ready");


 
    let canvas = document.createElement("canvas");

    let width = 1280;
    let height = 960;

    canvas.width = (video.width);
    canvas.height = (video.height);

    console.log("✅ Canvas created:", canvas.width, "x", canvas.height);

    let ctx = canvas.getContext("2d");
    if (!ctx) {
        console.error("🚨 Failed to get 2D context.");
        return "ERROR_CANVAS_CONTEXT";
    }
    console.error("test error");
    ctx.drawImage(video, 0, 0, canvas.width, canvas.height);
    console.log("i can draw");

    try {
        let imageData = canvas.toDataURL("image/jpeg",1);
        console.log("✅ Image captured successfully");
        console.log(imageData);

        return imageData;
    } catch (err) {
        console.error("🚨 Error during toDataURL():", err);
        return "ERROR_CAPTURE_FAILED";
    }
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


async function sendVidPids() {
    try {
        await navigator.mediaDevices.getUserMedia({ video: true });
    } catch (e) {
        console.error("Camera permission denied:", e);
        return;
    }

    const devices = await navigator.mediaDevices.enumerateDevices();
    const vidpids = devices
        .filter(d => d.kind === "videoinput")
        .map(cam => {
            const match = cam.label.match(/\((\w{4}:\w{4})\)/);
            return match ? match[1] : null;
        })
        .filter(v => v !== null);


    console.log("VID:PID list:", vidpids);

    return vidpids;

    //DotNet.invokeMethodAsync('YourAssemblyName', 'ReceiveVidPids', vidpids)
    //    .then(() => console.log("VID:PID list sent to .NET"))
    //    .catch(err => console.error("Error sending to .NET:", err));
}

async function getCookie(name) {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
    return null; // Return null if the cookie is not found
}





