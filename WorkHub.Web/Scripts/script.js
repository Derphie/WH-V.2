document.addEventListener("DOMContentLoaded", function () {
     // Selectare elemente
     const tabsBtns = document.querySelectorAll(".tabs__nav button");
     const tabsItems = document.querySelectorAll(".tabs__item");

     if (tabsBtns.length > 0 && tabsItems.length > 0) {
          // Funcție pentru ascunderea tab-urilor
          function hideTabs() {
               tabsItems.forEach(item => item.classList.add("hide"));
               tabsBtns.forEach(item => item.classList.remove("active"));
          }

          // Funcție pentru afișarea unui tab specific
          function showTab(index) {
               tabsItems[index].classList.remove("hide");
               tabsBtns[index].classList.add("active");
          }

          // Inițializare: ascundem toate tab-urile și afișăm primul
          hideTabs();
          showTab(0);

          // Eveniment pentru schimbarea tab-urilor la click
          tabsBtns.forEach((btn, index) => btn.addEventListener("click", () => {
               hideTabs();
               showTab(index);
          }));
     }

     // Navigare lină între secțiuni
     const anchors = document.querySelectorAll(".header__nav a");

     if (anchors.length > 0) {
          anchors.forEach(anc => {
               anc.addEventListener("click", function (event) {
                    event.preventDefault();

                    const id = anc.getAttribute("href");
                    const elem = document.querySelector(id);

                    if (elem) {
                         elem.scrollIntoView({ behavior: "smooth", block: "start" });
                    }
               });
          });
     }
});


//script pentru animatia headerului

let lastScrollTop = 0; // Poziția de scroll anterior
const header = document.querySelector("header"); // Selectează header-ul

window.addEventListener("scroll", function () {
     let currentScroll = window.pageYOffset || document.documentElement.scrollTop; // Poziția curentă de scroll

     if (currentScroll > lastScrollTop) {
          // Scroll în jos - ascunde header-ul
          header.style.top = "-80px"; // Ajustează valoarea pentru a se potrivi cu înălțimea header-ului
     } else {
          // Scroll în sus - arată header-ul
          header.style.top = "0"; // Arată header-ul
     }

     lastScrollTop = currentScroll <= 0 ? 0 : currentScroll; // Evită problemele cu scroll-ul negativ
});

// Funcționalitate pentru a arăta și ascunde săgeata de derulare
window.onscroll = function () { showScrollButton() };

function showScrollButton() {
     var scrollButton = document.getElementById("scroll-to-top");

     // Arată săgeata când utilizatorul derulează sub 200px (la jumătatea paginii)
     if (document.body.scrollTop > 3000 || document.documentElement.scrollTop > 3000) {
          scrollButton.style.display = "block";  // Arată săgeata
     } else {
          scrollButton.style.display = "none";  // Ascunde săgeata
     }
}

// La click, derulează pagina în sus
document.getElementById("scroll-to-top").onclick = function () {
     window.scrollTo({ top: 0, behavior: 'smooth' });
};

