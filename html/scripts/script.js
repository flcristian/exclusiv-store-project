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
  productButton.href = "products/product-" + data.id.toString() + ".html";
  productButton.textContent = "Detalii";
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

function handleKeyPress(event) {
  if(event.key == "Enter"){
    displayWithFilters();
  }
}

function returnData(){
  return fetch('data/products.json')
    .then(response => response.json())
    .then(data => {
      return data;
    });
}

function filterDataPriceAscending(data){
  data.sort(function(a, b){
    return a.price - b.price;
  });
}

function filterDataPriceDescending(data){
  data.sort(function(a, b){
    return b.price - a.price;
  });
}

function applyFilters(data){
  var filter = document.getElementById("product-filters");
  switch(filter.value){
    case "none":
      break;
    case "price-ascending":
      filterDataPriceAscending(data);
      break;
    case "price-descending":
      filterDataPriceDescending(data);
      break;
  }
}

function displayWithFilters(){
  returnData()
  .then(data =>{
    applyFilters(data);
    search(data);
  });
}

function containsInName(name, filter){
  if(name.toUpperCase().indexOf(filter) > -1){
    return true;
  }
  return false;
}

function containsInTags(tags, filter){
  for(i = 0;i<tags.length;i++){
    if(tags[i].toUpperCase().indexOf(filter) > -1){
      return true;
    }
  }
  return false;
}

function search(data){
  var input, filter, list, product, nomatches, i;
  input = document.getElementById('search-input');
  filter = input.value.toUpperCase();
  list = document.getElementById("product-list");
  nomatches = document.getElementById("no-matches");
  while(list.firstChild){
    list.removeChild(list.firstChild);
  }
  var count = 0;
  for(i = 0;i<data.length;i++){
    var products = [];
    if(containsInName(data[i].name, filter) || containsInTags(data[i].tags, filter)){
      list.appendChild(createProduct(data[i]));
      count = count + 1;
    }
  }
  if(count == 0){
     list.classList.add('change-product-list');
    nomatches.classList.add('change-no-matches');
  } 
  else{
     list.classList.remove('change-product-list');
     nomatches.classList.remove('change-no-matches');
  }
}

window.onload = function(){
  returnData()
  .then(data =>{
    search(data);
  })
}