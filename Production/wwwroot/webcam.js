function playCameraSound() {
    var audio = new Audio('/sounds/camera-shutter.mp3');
    audio.play();
}

window.blazorCameraSystem = {
    videoElements: [],
    streamRefs: [],



    startRearCamera: async function (videoId) {
        try {
            const video = document.getElementById(videoId);
            if (!video) {
                throw new Error(`Video element with ID '${videoId}' not found`);
            }

            // Stop existing streams
            this.stopCameras();

            const constraints = {
                video: {
                    facingMode: "environment",   // 👈 rear camera
                    width: { ideal: 1920 },
                    height: { ideal: 1080 }
                },
                audio: false
            };

            const stream = await navigator.mediaDevices.getUserMedia(constraints);
            this.streamRefs = [stream];
            this.videoElements = [video];
            video.srcObject = stream;

            await new Promise((resolve) => {
                video.onloadedmetadata = () => {
                    video.play();
                    resolve();
                };
            });

            return { success: true, message: "Rear camera started" };

        } catch (error) {
            console.error("Error starting rear camera:", error);
            this.stopCameras();
            return { success: false, error: error.message };
        }
    },

    captureImage: function (videoId, quality = 1.0) {
        try {
            const video = document.getElementById(videoId);
            if (!video) throw new Error(`Video element '${videoId}' not found`);
            if (video.readyState < 2) throw new Error("Video not ready");

            const canvas = document.createElement("canvas");
            canvas.width = video.videoWidth || 1920;
            canvas.height = video.videoHeight || 1080;

            const ctx = canvas.getContext("2d");
            ctx.drawImage(video, 0, 0, canvas.width, canvas.height);

            return {
                success: true,
                imageData: canvas.toDataURL("image/jpeg", quality),
                width: canvas.width,
                height: canvas.height,
                videoId: videoId
            };
        } catch (error) {
            console.error("Error capturing image:", error);
            return { success: false, error: error.message, videoId: videoId };
        }
    },

    stopCameras: function () {
        this.streamRefs.forEach(stream => {
            if (stream) stream.getTracks().forEach(track => track.stop());
        });

        this.videoElements.forEach(video => {
            if (video) {
                video.srcObject = null;
                video.onloadedmetadata = null;
            }
        });

        this.streamRefs = [];
        this.videoElements = [];
        return { success: true };
    }
};



