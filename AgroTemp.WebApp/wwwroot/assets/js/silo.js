window.drawSilo = (canvasId, probes) => {
    const canvas = document.getElementById(canvasId);
    if (!canvas) return;

    const ctx = canvas.getContext("2d");
    const centerX = 150;
    const centerY = 150;

    ctx.clearRect(0, 0, 300, 300);

    // Kopuła silosu
    ctx.beginPath();
    const gradient = ctx.createRadialGradient(centerX, centerY, 10, centerX, centerY, 120);
    gradient.addColorStop(0, "#eeeeee");
    gradient.addColorStop(1, "#888888");
    ctx.fillStyle = gradient;
    ctx.arc(centerX, centerY, 120, 0, 2 * Math.PI);
    ctx.fill();
    ctx.strokeStyle = "#333";
    ctx.lineWidth = 4;
    ctx.stroke();

    // Sondy
    for (let i = 0; i < probes.length; i++) {
        const angle = 2 * Math.PI * i / probes.length;
        const radius = probes[i].isInternal ? 65 : 100;
        const x = centerX + radius * Math.cos(angle);
        const y = centerY + radius * Math.sin(angle);

        ctx.beginPath();
        ctx.arc(x, y, 6, 0, 2 * Math.PI);
        ctx.fillStyle = "#ffcc00";
        ctx.fill();
        ctx.stroke();

        ctx.fillStyle = "black";
        ctx.font = "12px Arial";
        ctx.fillText(probes[i].label, x - 10, y - 10);
    }
};
