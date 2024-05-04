function moveCarouselOne(moveForward: boolean) {
    let currentDot = $('.carousel-dots > li.active');
    let currentItem = $('.carousel-item-view > div.active');
    if (moveForward) {
        currentDot.removeClass('active');
        currentItem.removeClass('active');
        if (currentDot.next('li') !== null && currentDot.next('li') !== undefined && currentDot.next('li').length > 0) {
            currentDot.next('li').addClass('active');
            currentItem.next('div').addClass('active');
        } else {
            currentDot.parent('ul').children().first().addClass('active');
            currentItem.parent('div').children().first().addClass('active');
        }
    } else {
        currentDot.removeClass('active');
        currentItem.removeClass('active');
        if (currentDot.prev('li') !== null && currentDot.prev('li') !== undefined && currentDot.prev('li').length > 0) {
            currentDot.prev('li').addClass('active');
            currentItem.prev('div').addClass('active');
        } else {
            currentDot.parent('ul').children().last().addClass('active');
            currentItem.parent('div').children().last().addClass('active');
        }
    }
}


// Call for changing the calendar table in booking calendar
// TODO: Clean this up make one call
function createCalendar(year: number, month: number, currentDate: number) {
    let startDateOfMonth = (new Date(year, month)).getDate();
    let calendarDate = 0 - currentDate;
    let lastDayOfMonth = (new Date(year, month + 1, 0)).getDate();
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
    let todaysDate = new Date();
    createCalendar(todaysDate.getFullYear(), todaysDate.getMonth(), todaysDate.getDay());
}

//Load the calendar based on button click event
function moveCalendarOneMonth(direction: string) {
    let currentMonth = $('#month-list > li.active');
    if ('previous') {
        //Check for December
        if (currentMonth.next('li') != null) {

        } else {

        }
    } else {

    }

}

// Set all the event listeners
// Events page
$('.left-carousel-arrow > div').on('click', (event: JQuery.Event) => { moveCarouselOne(false) });
$('.right-carousel-arrow > div').on('click', (event: JQuery.Event) => { moveCarouselOne(true) });
// Months page
$('.left-month-arrow > div').on('click', (event: JQuery.Event) => { moveCalendarOneMonth('previous') });
$('.right-month-arrow > div').on('click', (event: JQuery.Event) => { moveCalendarOneMonth('next') });



window.onload = function () {
    initialCalendarLoad();
}