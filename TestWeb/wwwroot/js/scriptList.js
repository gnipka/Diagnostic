items = document.getElementsByClassName('symptom');
var arrN = [];
var symptom = document.getElementById('btn-Symptom');
symptom.addEventListener('click', function (event) {
    for (var i = 0; i < items.length; i++) {
        if (items[i].checked) {
            arrN[i] = items[i].id;
        }
    }


    return arrN;
});
