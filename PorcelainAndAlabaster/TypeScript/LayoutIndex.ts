function showMainMenu() {
    let mainMenu = $('.navbar-main-menu-toggler');
    if (mainMenu.hasClass('active')) {
        $('.navbar-nav').addClass('hidden');
        mainMenu.removeClass('active');
        mainMenu.addClass('inactive');
    } else {
        $('.navbar-nav').removeClass('hidden');
        mainMenu.removeClass('inactive');
        mainMenu.addClass('active');
    }
}
$('.navbar-main-menu-toggler').on('click', (event: JQuery.Event) => { showMainMenu() });