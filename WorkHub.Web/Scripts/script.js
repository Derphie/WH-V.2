document.addEventListener("DOMContentLoaded", function () {
     // Tabs logic (dacă există)
     const tabsBtns = document.querySelectorAll(".tabs__nav button");
     const tabsItems = document.querySelectorAll(".tabs__item");

     if (tabsBtns.length > 0 && tabsItems.length > 0) {
          function hideTabs() {
               tabsItems.forEach(item => item.classList.add("hide"));
               tabsBtns.forEach(item => item.classList.remove("active"));
          }

          function showTab(index) {
               tabsItems[index].classList.remove("hide");
               tabsBtns[index].classList.add("active");
          }

          hideTabs();
          showTab(0);

          tabsBtns.forEach((btn, index) => {
               btn.addEventListener("click", () => {
                    hideTabs();
                    showTab(index);
               });
          });
     }

     // Navigare lină DOAR pentru ancore locale (href="#...")
     const anchors = document.querySelectorAll(".header__nav a");

     if (anchors.length > 0) {
          anchors.forEach(anc => {
               anc.addEventListener("click", function (event) {
                    const href = anc.getAttribute("href");

                    if (href && href.startsWith("#")) {
                         event.preventDefault();

                         const target = document.querySelector(href);
                         if (target) {
                              target.scrollIntoView({ behavior: "smooth", block: "start" });
                         }
                    }
               });
          });
     }
});

// Animatie header la scroll
let lastScrollTop = 0;
const header = document.querySelector("header");

window.addEventListener("scroll", function () {
     let currentScroll = window.pageYOffset || document.documentElement.scrollTop;

     if (currentScroll > lastScrollTop) {
          header.style.top = "-80px"; // ascunde
     } else {
          header.style.top = "0"; // arată
     }

     lastScrollTop = Math.max(currentScroll, 0);
});

// Scroll to top button logic
window.onscroll = function () {
     showScrollButton();
};

function showScrollButton() {
     var scrollButton = document.getElementById("scroll-to-top");

     if (document.body.scrollTop > 3000 || document.documentElement.scrollTop > 3000) {
          scrollButton.style.display = "block";
     } else {
          scrollButton.style.display = "none";
     }
}

document.getElementById("scroll-to-top").onclick = function () {
     window.scrollTo({ top: 0, behavior: 'smooth' });
};
