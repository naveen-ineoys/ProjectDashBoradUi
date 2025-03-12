document.getElementById('selectAll').addEventListener('change', function () {
    const isChecked = this.checked;
    document.querySelectorAll('.selectItem').forEach(item => {
        if (!item.disabled) {
            item.checked = isChecked;
            item.dispatchEvent(new Event('change')); 
        }
    });
});
document.querySelectorAll('.room-checkbox').forEach(item => {
    item.addEventListener('change', function () {
        if (!this.checked) {
            document.getElementById('selectAll').checked = false;
        }
        // If all are checked, check the Select All
        else if (document.querySelectorAll('.room-checkbox:checked').length ===
            document.querySelectorAll('.room-checkbox:not(:disabled)').length) {
            document.getElementById('selectAll').checked = true;
        }
    });
});

