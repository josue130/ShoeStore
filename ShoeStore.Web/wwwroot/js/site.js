// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function zoom(event) {
    const img = event.currentTarget.querySelector('.card-img-top');
    const { left, top, width, height } = event.currentTarget.getBoundingClientRect();
    const x = ((event.clientX - left) / width) * 100;
    const y = ((event.clientY - top) / height) * 100;

    img.style.transform = `scale(2)`;
    img.style.transformOrigin = `${x}% ${y}%`;
}

function resetZoom() {
    const img = document.querySelector('.card-img-top');
    img.style.transform = `scale(1)`;
}