function moveCarouselOne(moveForward: boolean) {
    if (moveForward) {
        let currentDot = $('.carousel-dots.active');
        let currentItem = $('.carousel-item-view > div.active');
        currentDot.removeClass('active');
        currentItem.removeClass('active');
        if (currentDot.next('li') !== null || currentDot.next('li') !== undefined) {
            currentDot.next('li').addClass('active');
            currentItem.next('div').addClass('active');
        } else {
            currentDot.parent('ul').children().first().addClass('active');
            currentItem.parent('div').children().first().addClass('active');
        }
    } else {
        let currentDot = $('.carousel-dots.active');
        let currentItem = $('.carousel-item-view > div.active');
        currentDot.removeClass('active');
        currentItem.removeClass('active');
        if (currentDot.prev('li') !== null || currentDot.prev('li') !== undefined) {
            currentDot.prev('li').addClass('active');
            currentItem.prev('div').addClass('active');
        } else {
            currentDot.parent('ul').children().last().addClass('active');
            currentItem.parent('div').children().last().addClass('active');
        }
    }

}