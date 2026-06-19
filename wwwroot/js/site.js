// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.initTooltips = function() {
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    tooltipTriggerList.map(function (tooltipTriggerEl) {
      return new bootstrap.Tooltip(tooltipTriggerEl);
    });
};

window.initDragToScroll = function() {
    const sliders = document.querySelectorAll('.table-responsive, .kanban-board-container');
    
    sliders.forEach(slider => {
        if(slider._hasDragListener) return;
        slider._hasDragListener = true;
        
        let isDown = false;
        let startX;
        let scrollLeft;
        let startY;
        let scrollTop;

        slider.addEventListener('mousedown', (e) => {
            // Prevent grabbing on interactive elements
            const tag = e.target.tagName.toLowerCase();
            if(tag === 'a' || tag === 'button' || tag === 'select' || tag === 'input' || e.target.closest('.dropdown')) {
                return;
            }
            
            // Prevent grabbing if clicking on the physical scrollbar area
            const rect = slider.getBoundingClientRect();
            const isScrollbarY = slider.scrollHeight > slider.clientHeight && e.clientX >= rect.right - 18;
            const isScrollbarX = slider.scrollWidth > slider.clientWidth && e.clientY >= rect.bottom - 18;
            if (isScrollbarX || isScrollbarY || e.target === slider && (e.offsetX >= slider.clientWidth || e.offsetY >= slider.clientHeight)) {
                return;
            }
            
            isDown = true;
            slider.style.cursor = 'grabbing';
            document.body.style.userSelect = 'none'; // Prevent text selection
            startX = e.pageX - slider.offsetLeft;
            startY = e.pageY - slider.offsetTop;
            scrollLeft = slider.scrollLeft;
            scrollTop = slider.scrollTop;
        });
        
        slider.addEventListener('mouseleave', () => {
            isDown = false;
            slider.style.cursor = '';
            document.body.style.userSelect = '';
        });
        
        slider.addEventListener('mouseup', () => {
            isDown = false;
            slider.style.cursor = '';
            document.body.style.userSelect = '';
        });
        
        slider.addEventListener('mousemove', (e) => {
            if (!isDown) return;
            const x = e.pageX - slider.offsetLeft;
            const y = e.pageY - slider.offsetTop;
            const walkX = (x - startX) * 1.5;
            const walkY = (y - startY) * 1.5;
            slider.scrollLeft = scrollLeft - walkX;
            slider.scrollTop = scrollTop - walkY;
        });
    });
};
