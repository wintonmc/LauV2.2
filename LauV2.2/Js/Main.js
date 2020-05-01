(function ($) {
 
        //do work
    $("body > div.navigation > div.nav-down > div > div.nav").remove();
    $("body > div.navigation > div.nav - down > div > div.nav").remove();
    $("body > div.navigation > div.nav-down > div > div.nav-other").remove();
    
    var menu = document.querySelector('body > div.navigation > div.nav-down > div > div.nav-drop > div.game-list > ul');
    menu.innerHTML = "";
    var elementoLI = document.createElement("li");
    elementoLI.innerHTML = '<a  href="https://www.gamesow.com/member/logout/?referer=https://mses2.gamesow.com/"><i><img style="width:16px;height:16px;" src=""></i><span>Salir del juego</span></a>"';
    menu.appendChild(elementoLI);

     
   
})(jQuery);
