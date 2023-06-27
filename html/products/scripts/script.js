function returnData(){
  return fetch('../data/products.json')
    .then(response => response.json())
    .then(data => {
      return data;
    });
}

function buttonPressed(left){
  var button;
  if(left){
    button = document.getElementById("left-image-button");
  }else{
    button = document.getElementById("right-image-button");
  }

  button.classList.add("change-button-color");
  setTimeout(() => {
    button.classList.remove("change-button-color");
  }, 200);
}

function previousImage(){
 // BUTTON COLOR CHANGE
 buttonPressed(true);
  
  // IMAGE CHANGE
  var url = window.location.href;
  var fileName = url.substring(url.lastIndexOf("-") + 1);
  var string = fileName.slice(0, -5);
  var id = Number(string);

  returnData()
  .then(data =>{
  var index = -1;
  for(var i = 0;i < data.length; i++){
    if(data[i].id == id){
      index = i;
    }
    break;
  }
  var  imagePaths = data[index].paths;
  const image = document.getElementById("product-image");
  const currentIndex = imagePaths.indexOf(image.src);
  const newIndex = (currentIndex - 1 + imagePaths.length) % imagePaths.length;
  image.src = imagePaths[newIndex];
  });
}

function nextImage(){
  // BUTTON COLOR CHANGE
  buttonPressed(false);

   // IMAGE CHANGE
   var url = window.location.href;
   var fileName = url.substring(url.lastIndexOf("-") + 1);
   var string = fileName.slice(0, -5);
   var id = Number(string);
 
   returnData()
   .then(data =>{
   var index = -1;
   for(var i = 0;i < data.length; i++){
     if(data[i].id == id){
       index = i;
     }
     break;
   }
   var  imagePaths = data[index].paths;
   const image = document.getElementById("product-image");
   const currentIndex = imagePaths.indexOf(image.src);
   const newIndex = (currentIndex + 1) % imagePaths.length;
   image.src = imagePaths[newIndex];
   });
}

function openOverlay() {
  var imageUrl = document.getElementById('product-image').src;
  var overlay = document.getElementById('overlay');
  var overlayImage = document.getElementById('overlay-image');
  overlayImage.src = imageUrl;
  overlay.style.display = 'flex';
}

function closeOverlay() {
  var overlay = document.getElementById('overlay');
  overlay.style.display = 'none';
}