//// DOM Content Loaded Event
//document.addEventListener('DOMContentLoaded', function() {
//    // Modal functionality
//    setupModals();
    
//    // Handle file upload logic if on upload page
//    if (document.getElementById('fileUpload')) {
//        setupFileUpload();
//    }
    
//    // Handle FAQ toggle if on upload page
//    const faqItems = document.querySelectorAll('.faq-item');
//    if (faqItems.length > 0) {
//        setupFAQToggle(faqItems);
//    }
    
//    // Handle form submissions
//    //setupFormSubmissions();
    
//    // Handle pagination if on browse page
//    const pagination = document.querySelector('.pagination');
//    if (pagination) {
//        setupPagination();
//    }
    
//    // Handle filter functionality if on browse page
//    const filterForm = document.getElementById('filterForm');
//    if (filterForm) {
//        setupFilters();
//    }
//});

//// Modal Setup
//function setupModals() {
//    const loginBtn = document.getElementById('loginBtn');
//    const loginModal = document.getElementById('loginModal');
//    const registerModal = document.getElementById('registerModal');
//    const showRegister = document.getElementById('showRegister');
//    const showLogin = document.getElementById('showLogin');
//    const closeBtns = document.querySelectorAll('.close');
    
//    // Open login modal
//    if (loginBtn) {
//        loginBtn.addEventListener('click', function(e) {
//            e.preventDefault();
//            loginModal.style.display = 'block';
//        });
//    }
    
//    // Switch to register modal
//    if (showRegister) {
//        showRegister.addEventListener('click', function(e) {
//            e.preventDefault();
//            loginModal.style.display = 'none';
//            registerModal.style.display = 'block';
//        });
//    }
    
//    // Switch to login modal
//    if (showLogin) {
//        showLogin.addEventListener('click', function(e) {
//            e.preventDefault();
//            registerModal.style.display = 'none';
//            loginModal.style.display = 'block';
//        });
//    }
    
//    // Close modals
//    closeBtns.forEach(btn => {
//        btn.addEventListener('click', function() {
//            loginModal.style.display = 'none';
//            registerModal.style.display = 'none';
//        });
//    });
    
//    // Close modal when clicking outside
//    window.addEventListener('click', function(e) {
//        if (e.target === loginModal) {
//            loginModal.style.display = 'none';
//        }
//        if (e.target === registerModal) {
//            registerModal.style.display = 'none';
//        }
//    });
//}