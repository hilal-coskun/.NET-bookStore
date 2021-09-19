function geri() {
    window.history.back()
}

$(document).ready(function () {

    $(".hamburger .fas").click(function () {
        $(".wrapper").addClass("active");
    })

    $(".close").click(function () {
        $(".wrapper").removeClass("active");
    })
})



/*document.querySelector("#plus").addEventListener("click", function (e) {

    const createCard = document.querySelector("#card");
    const cardEl = document.createElement("div");
    cardEl.innerHTML = `
    <div class="row">
        <div class="col-25" style="margin-top: 7px;">
            <button id="delete" onclick="deleteElement()" style="border: none; cursor: pointer;"><i class="fas fa-minus-square" style="font-size: 20px; color: #7a91c0;"></i></button>
            <input type="text" name="bookName" id="bookName">
        </div>
        <div class="col-25" style="margin-top: 5px;">
            <input type="number" name="" id="" style="padding: 7px; border: .5px solid rgb(211, 206, 206); appearance:textfield ; ">
        </div>
    </div>
    `;

    createCard.appendChild(cardEl);

    e.preventDefault();
});*/

var deleteButon = document.querySelector('#delete');

function deleteElement() {
    deleteButon.removeChild();
}