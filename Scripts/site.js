function printFiles(input) {
    var files = document.getElementById("test").elements["file_upload"];
    //console.log(files.value);
    //console.log(input.files.length);
    for (x in input.files) {
        console.log(x.filename);
    }

    prod.img = input.value;
    prod.isDisplay() = 

}

function getFiles (input) {
        if (input.files && input.files[0]) {

            var imgs = document.getElementById("img-list");
            while (imgs.firstChild) {
                imgs.removeChild(imgs.firstChild);
            }
            
            $(input.files).each(function () {
                document.getElementById("listing_images").style.display = 'block';
                var reader = new FileReader();
                reader.readAsDataURL(this);
                reader.onload = function (e) {
                    var item = createRadioImage(e);
                    $("#img-list").append(item);
                }
            });
        }
    }

function submitCreateForm() {

    var product = new Object();
    product.Title = form.elements["product_title"].value;
    product.Description = form.elements["product_desc"].value;
    product.Price = form.elements["product_price"].value;
    product.Category = form.elements["product_cat"].value;

    if (!validateRadio()) {
        alert("Error");
    }

    product.Files = form.elements["files"].value;
    product.DisplayPic = validateRadio();
    console.log(product.DisplayPic);
    console.log(JSON.stringify(product));

    $.ajax({
        url: '@Url.Action("Create", "Store")',
        type: 'POST',
        dataType: 'json',
        data: JSON.stringify(product),
        contentType: "application/json; charset=utf-8"
    });
}

function validateRadio() {
        
    var imgList = document.getElementById("img-list").childNodes;

    for (var i = 0; i < imgList.length; i++) {
        //console.log(imgList[i].childNodes[1].src);
        if (imgList[i].childNodes[0].checked) {
            console.log(imgList[i].childNodes[1].src);
            return imgList[i].childNodes[1].src;
        }
    }
    return false;
}

function check(parentNode) {
    validateRadio();
}

function createRadioImage(e) {
    var label = document.createElement("label");
    label.setAttribute("onclick", "check(this)");

    var input = document.createElement("input");
    input.setAttribute("type", "radio");
    input.setAttribute("name", "img_radio");

    var img = document.createElement("img");
    img.src = e.target.result;

    label.appendChild(input);
    label.appendChild(img);
    return label;
}
