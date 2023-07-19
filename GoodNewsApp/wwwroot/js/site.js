// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const topic = document.getElementById("topic");

document.addEventListener("click", function () {
    topic.style.color = "orange";
    topic.style.textDecoration = "underline";
})

function onClickNavItem(event) {
    // Remove previous active item styles
    const activeItems = document.querySelectorAll(".active");
    activeItems.forEach(item => {
        item.classList.remove("active");
    });

    // Add active item styles to the clicked item
    const clickedItem = event.target;
    clickedItem.classList.add("active");
}

// Attach onClick event listeners to navbar items
const navbarItems = document.querySelectorAll(".hover:text-orange-500.hover:underline.font-bold");
navbarItems.forEach(item => {
    item.addEventListener("click", onClickNavItem);
});