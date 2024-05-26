function moveCarouselOne(moveForward) {
    var currentDot = $('.carousel-dots > li.active');
    var currentItem = $('.carousel-item-view > div.active');
    if (moveForward) {
        currentDot.removeClass('active');
        currentItem.removeClass('active');
        if (currentDot.next('li') !== null && currentDot.next('li') !== undefined && currentDot.next('li').length > 0) {
            currentDot.next('li').addClass('active');
            currentItem.next('div').addClass('active');
        }
        else {
            currentDot.parent('ul').children().first().addClass('active');
            currentItem.parent('div').children().first().addClass('active');
        }
    }
    else {
        currentDot.removeClass('active');
        currentItem.removeClass('active');
        if (currentDot.prev('li') !== null && currentDot.prev('li') !== undefined && currentDot.prev('li').length > 0) {
            currentDot.prev('li').addClass('active');
            currentItem.prev('div').addClass('active');
        }
        else {
            currentDot.parent('ul').children().last().addClass('active');
            currentItem.parent('div').children().last().addClass('active');
        }
    }
}
// Call for changing the calendar table in booking calendar
// TODO: Clean this up make one call
function createCalendar(year, month, currentDate) {
    var startDateOfMonth = (new Date(year, month)).getDate();
    var calendarDate = 0 - currentDate;
    var lastDayOfMonth = (new Date(year, month + 1, 0)).getDate();
    // Handle the days that are not the start of the month
    $('.first-week').children().each(function () {
        if (calendarDate > 0) {
            $(this).text(calendarDate.toString());
        }
        calendarDate++;
    });
    // Handle the rest
    $('.second-week').children().each(function () {
        if (calendarDate <= lastDayOfMonth) {
            $(this).text(calendarDate.toString());
        }
        calendarDate++;
    });
    $('.third-week').children().each(function () {
        if (calendarDate <= lastDayOfMonth) {
            $(this).text(calendarDate.toString());
        }
        calendarDate++;
    });
    $('.fourth-week').children().each(function () {
        if (calendarDate <= lastDayOfMonth) {
            $(this).text(calendarDate.toString());
        }
        calendarDate++;
    });
    $('.fifth-week').children().each(function () {
        if (calendarDate <= lastDayOfMonth) {
            $(this).text(calendarDate.toString());
        }
        calendarDate++;
    });
}
//Load the first calendar based on current date for booking calendar
function initialCalendarLoad() {
    var todaysDate = new Date();
    createCalendar(todaysDate.getFullYear(), todaysDate.getMonth(), todaysDate.getDay());
}
//Load the calendar based on button click event
function moveCalendarOneMonth(direction) {
    var currentMonth = $('#month-list > li.active');
    if ('previous') {
        //Check for December
        if (currentMonth.next('li') != null) {
        }
        else {
        }
    }
    else {
    }
}
// Set all the event listeners
// Events page
$('.left-carousel-arrow > div').on('click', function (event) { moveCarouselOne(false); });
$('.right-carousel-arrow > div').on('click', function (event) { moveCarouselOne(true); });
// Months page
$('.left-month-arrow > div').on('click', function (event) { moveCalendarOneMonth('previous'); });
$('.right-month-arrow > div').on('click', function (event) { moveCalendarOneMonth('next'); });
// Contact page
$('#contact-us').on('submit', function (event) {
    event.preventDefault();
    var contact = { firstName: $('#contact-us-first-name-input').val(), lastName: $('#contact-us-last-name-input').val(), email: $('#contact-us-email-input').val(), question: $('#contact-us-question-textarea').val() };
    $.post('/home/contactSubmit', contact);
});
// ILL Request
$('#ill-request').on('submit', function (event) {
    event.preventDefault();
    var illRequest = { firstName: $('#ill-request-first-name-input').val(), lastName: $('#ill-request-last-name-input').val(), email: $('#ill-request-email-input').val(), libraryCardNumber: $('#ill-request-library-card-input').val(), title: $('#ill-request-title-input').val(), author: $('#ill-request-author-input').val(), journal: $('#ill-request-journal-input').val(), volume: $('#ill-request-volume-input').val(), year: $('#ill-request-year-input').val(), isbn: $('#ill-request-isbn-input').val()  };
    $.post('/home/iLLSubmit', illRequest);
});
window.onload = function () {
    initialCalendarLoad();
};
function showMainMenu() {
    var mainMenu = $('.navbar-main-menu-toggler');
    if (mainMenu.hasClass('active')) {
        $('.navbar-nav').addClass('hidden');
        mainMenu.removeClass('active');
        mainMenu.addClass('inactive');
    }
    else {
        $('.navbar-nav').removeClass('hidden');
        mainMenu.removeClass('inactive');
        mainMenu.addClass('active');
    }
}
$('.navbar-main-menu-toggler').on('click', function (event) { showMainMenu(); });
