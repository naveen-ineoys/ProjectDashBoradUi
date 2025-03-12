window.addEventListener("resize",
    function () {
        var navdiv = document.getElementById("nav-bar-div");
        var layoutmain = document.getElementById("layout");
        if (window.innerWidth <= 768) { // Example for Android view width
            navdiv.classList.add("up-nav-bar");
            layoutmain.classList.add("mm-div");
            navdiv.classList.remove("side-nav-bar");
            layoutmain.classList.remove("full-div");
        }
        else {
            navdiv.classList.remove("up-nav-bar");
            layoutmain.classList.remove("mm-div");
            navdiv.classList.add("side-nav-bar");
            layoutmain.classList.add("full-div");

        }
    });

    