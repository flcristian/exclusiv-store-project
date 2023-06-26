window.addEventListener('scroll', function() {
    const navbar = document.getElementById('navbar');
    const scrollTop = window.pageYOffset || document.documentElement.scrollTop;
    
    if (scrollTop > 100) {
      navbar.classList.add('change-navbar');
    } else {
      navbar.classList.remove('change-navbar');
    }
});