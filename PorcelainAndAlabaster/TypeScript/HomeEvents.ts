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

$('.left-carousel-arrow > button').on('click', (event: JQuery.Event) => { moveCarouselOne(false) });
$('.right-carousel-arrow > button').on('click', (event: JQuery.Event) => { moveCarouselOne(true) });