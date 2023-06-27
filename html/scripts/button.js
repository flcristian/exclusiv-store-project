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
  const imagePaths = [
    'https://placehold.it/320x480?text=image1',
    'https://placehold.it/320x480?text=image2',
    'https://placehold.it/320x480?text=image3'
  ];
  var lenght= 0;
  while(imagePaths[lenght]){
    lenght++;
  }
  const image = document.getElementById("product-image");
  const currentIndex = imagePaths.indexOf(image.src);
  const index = (currentIndex - 1 + lenght) % lenght;
  image.src = imagePaths[index];
}

function nextImage(){
  // BUTTON COLOR CHANGE
  buttonPressed(false);

   // IMAGE CHANGE
  const imagePaths = [
    'https://placehold.it/320x480?text=image1',
    'https://placehold.it/320x480?text=image2',
    'https://placehold.it/320x480?text=image3'
  ];
  var lenght= 0;
  while(imagePaths[lenght]){
    lenght++;
  } 
  const image = document.getElementById("product-image");
  const currentIndex = imagePaths.indexOf(image.src);
  const index = (currentIndex + 1) % lenght;
  image.src = imagePaths[index];
}