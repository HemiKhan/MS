let arrow = document.querySelectorAll(".arrow");
for (var i = 0; i < arrow.length; i++) {
  arrow[i].addEventListener("click", (e) => {
    let arrowParent = e.target.parentElement.parentElement; //selecting main parent of arrow
    arrowParent.classList.toggle("showMenu");
  });
}

// let sidebar = document.querySelector(".sidebar");
// let sidebarBtn = document.querySelector(".home-content .bx-menu");
// console.log(sidebarBtn);
// sidebarBtn.addEventListener("click", ()=>{
//   sidebar.classList.toggle("close");
// });

let getMode = localStorage.getItem("mode");
if (getMode && getMode === "dark-mode") {
  $(".BodyContainer").addClass("dark");
}

$(".SidebarToggle").click(function () {
  $(".SidebarToggle").toggleClass("active");
  $(".sidebar").toggleClass("close");
});

$(".theme").click(function () {
  $(".theme").toggleClass("active");
  $(".BodyContainer").toggleClass("dark");

  if (!$(".BodyContainer").hasClass("dark")){
    localStorage.setItem("mode", "light-mode");
  } 
  else {
    localStorage.setItem("mode", "dark-mode");
  }
});

$(".SidebarToggle").click(function () {
  $(nav).addClass("active");
});

$(".searchToggle").click(function () {
  $(".searchToggle").toggleClass("active");
});

const body = document.querySelector("BodyContainer"),
  nav = document.querySelector("nav");

body.addEventListener("click", (e) => {
  let clickedElm = e.target;

  if (
    !clickedElm.classList.contains("SidebarToggle") &&
    !clickedElm.classList.contains("menu")
  ) {
    nav.classList.remove("active");
  }
});
