
tabContent = document.getElementsByClassName('tab-content');
tab = document.getElementsByClassName('tab');
items = document.getElementsByClassName('symptom');


var tabs = document.getElementsByClassName('tab');
for (item of tabs) {
    item.addEventListener('click', function (event) {
        var target = event.target;
        for (var i = 0; i < tabContent.length; i++) {
            if (event.target.id == tabContent[i].id) {
                tabContent[i].classList.add('show');
                tabContent[i].classList.remove('hide');
            }
            else {
                tabContent[i].classList.add('hide');
                tabContent[i].classList.remove('show');
            }
        }
    });
};

var data;
var arrN = [];
var orderFormData = new FormData();
var symptom = document.getElementById('btn-Symptom');
symptom.addEventListener('click', function (event) {
    for (var i = 0; i < items.length; i++) {
        if (items[i].checked) {
            arrN[i] = items[i].id;
            orderFormData.append(i, arrN[i]);
        }
    }

    axios.post('/Home/Diagnostic', arrN)
        .then(function (response) {
            data = response.data;
            localStorage.setItem("symptoms", JSON.stringify(response.data.symptoms));
            document.location = "/Home/Diagnostic?Name=" + data.name + "&Age=" + data.age + "&Gender=" + data.gender + "&Disease=" + data.disease;

        })
        .catch(function (error) {
            console.log(error);
        })
        .then(function () { });
});

function search() {
    let input = document.getElementById("inputSearch");
    let filter = input.value.toUpperCase();
    let ul = document.getElementsByClassName('tab');
    let li = document.getElementsByClassName('tab-content');

    // Перебирайте все элементы списка и скрывайте те, которые не соответствуют поисковому запросу
    for (let i = 0; i < li.length; i++) {
        let a = li[i].getElementsByTagName("span")[0];
        if (a.innerHTML.toUpperCase().indexOf(filter) > -1) {
            li[i].classList.add('show');
            li[i].classList.remove('hide');
        } else {
            li[i].classList.add('hide');
            li[i].classList.remove('show');
        }
    }
}

document.addEventListener('keyup', search);


//var name = document.getElementById('name');
//var age = document.getElementById('age');
//var gender = document.getElementById('gender');
//var symptomdisease = document.getElementById('symptomdisease');
//var disease = document.getElementById('disease');

//function diagnostic() {
//    data = document.location.search;
//    name.innerHTML = data.Name;
//    age.innerHTML = data.Age;
//    gender.innerHTML = data.Gender;
//    symptomdisease.innerHTML = data.Symptoms;
//    disease.innerHTML = data.Disease;
//}

window.onload = () => {
    var query = decodeURI(window.location.href).split("?")[1]; // результат - строка запроса без адреса страницы "id=someName&userMail=some@mail.com&usText=MemoText"
    var params = query.split("&");  // результат - массив строк из пар "id=someName", "userMail=some@mail.com", "usText=MemoText"
    // теперь брать по очереди
    document.getElementById('name').innerHTML = params[0].split("=")[1];
    document.getElementById('age').innerHTML = params[1].split("=")[1];
    document.getElementById('gender').innerHTML = params[2].split("=")[1];
    document.getElementById('disease').innerHTML = params[3].split("=")[1];

    var array = JSON.parse(localStorage.getItem("symptoms"));
    for (item of array) {
        var newSymptom = document.createElement('span');
        newSymptom.textContent = item.name + '  ';
        var symptom = document.querySelector('#symptoms');
        symptom.appendChild(newSymptom);
    }

    if (params[2].split("=")[1] == "мужской") {
        document.getElementById("image").src = "/img/man.png";
    }
    else {
        document.getElementById("image").src = "/img/woman.png";
    }
    //name.innerHTML = data.Name;
    //age.innerHTML = data.Age;
    //gender.innerHTML = data.Gender;
    //symptomdisease.innerHTML = data.Symptoms;
    //disease.innerHTML = data.Disease;
}