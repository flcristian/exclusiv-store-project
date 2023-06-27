function checkImageExists(imageUrl, callback) {
  var img = new Image();
  
  img.onload = function() {
    callback(true);
  };
  
  img.onerror = function() {
    callback(false);
  };
  
  img.src = imageUrl;
}

function createProduct(data){
  const productItem = document.createElement("article");
  productItem.classList.add("product-item");
  const productImage = document.createElement("img");
  productImage.classList.add("product-image");
  checkImageExists(data.path, function(exists) {
    if (exists) {
      productImage.src = data.path;
      productImage.alt = data.description;
    } else {
      productImage.src = "https://placehold.it/240x320?text=ERROR_404_Image_file_not_found";
      productImage.alt = 'ERROR 404 - Image file not found';
    }
  });
  const productNameArea = document.createElement("div");
  productNameArea.classList.add('product-name-area');
  const productName = document.createElement("div");
  productName.classList.add('product-name');
  productName.textContent = data.name;
  productNameArea.appendChild(productName);
  const productPrice = document.createElement("div");
  productPrice.classList.add("product-price");
  productPrice.textContent = data.price + " RON";
  const stockWarning = !data.stock;
  const productStockWarningArea = document.createElement("section");
  productStockWarningArea.classList.add("product-stock-warning");
  const productStockWarning = document.createElement("p");
  productStockWarning.classList.add("product-stock-warning-text");
  productStockWarning.textContent = "Stoc epuizat";
  productStockWarningArea.appendChild(productStockWarning);
  const productButtonArea= document.createElement("div");
  productButtonArea.classList.add("product-button");
  const productButton = document.createElement("a");
  productButton.classList.add("product-button-text");
  productButton.href = "#contact";
  productButton.textContent = "Contact";
  productButtonArea.appendChild(productButton);
  productItem.appendChild(productImage);
  productItem.appendChild(productNameArea);
  productItem.appendChild(productPrice);
  if(stockWarning){
    productItem.appendChild(productStockWarningArea);
    console.log(productStockWarning.textContent);
  }
  productItem.appendChild(productButtonArea);

  return productItem;
}

window.onload = function(){
    fetch('data/products.json')
    .then(response => response.json())
    .then(data => {
        const productList = document.getElementById('product-list');
        
        for(i = 0;i<data.length;i++){
           // ADDING PRODUCT ITEM TO LIST
           productList.appendChild(createProduct(data[i]));
        }
    });
}