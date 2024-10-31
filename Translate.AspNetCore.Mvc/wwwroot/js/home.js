
// Dark mode toggle
const themeToggle = document.querySelector('.toggle-mode');
const prefersDarkScheme = window.matchMedia('(prefers-color-scheme: dark)');

// Check for saved theme preference or use system preference
const currentTheme = localStorage.getItem('theme') || 
    (prefersDarkScheme.matches ? 'dark' : 'light');
document.documentElement.setAttribute('data-theme', currentTheme);

themeToggle.addEventListener('click', () => {
    const currentTheme = document.documentElement.getAttribute('data-theme');
    const newTheme = currentTheme === 'light' ? 'dark' : 'light';
    
    document.documentElement.setAttribute('data-theme', newTheme);
    localStorage.setItem('theme', newTheme);
});

// Mobile menu toggle
const mobileMenuBtn = document.querySelector('.mobile-menu-btn');
const navLinks = document.querySelector('.nav-links');

mobileMenuBtn.addEventListener('click', () => {
    navLinks.classList.toggle('active');
    
    // Animate hamburger menu
    const spans = mobileMenuBtn.querySelectorAll('span');
    spans.forEach(span => span.classList.toggle('active'));
});


document.addEventListener('DOMContentLoaded', () => {
    // DOM elementlerini seçme
    const fromLang = document.querySelector('.from-lang');
    const toLang = document.querySelector('.to-lang');
    const swapBtn = document.querySelector('.swap-lang');
    const inputText = document.querySelector('.input-text');
    const outputText = document.querySelector('.output-text');
    const charCount = document.querySelector('.char-count');
    const clearTextBtn = document.querySelector('.clear-text');
    const copyTextBtn = document.querySelector('.copy-text');
    

    // Karakter sayısını güncelleme
    inputText.addEventListener('input', () => {
        const length = inputText.value.length;
        charCount.textContent = `${length}/5000`;
    });

    // Dilleri değiştirme
    swapBtn.addEventListener('click', () => {
        const tempLang = fromLang.value;
        fromLang.value = toLang.value;
        toLang.value = tempLang;

        const tempText = inputText.value;
        inputText.value = outputText.value;
        outputText.value = tempText;

        updateCharCount();
    });


    clearTextBtn.addEventListener('click', () => {
        inputText.value = '';
        outputText.value = '';
        updateCharCount();
    });

    // Metni kopyalama
    copyTextBtn.addEventListener('click', async () => {
        try {
            await navigator.clipboard.writeText(outputText.value);
            showNotification('Metin kopyalandı!');
        } catch (err) {
            showNotification('Kopyalama başarısız oldu!', 'error');
        }
    });

   
    // Bildirim gösterme
    function showNotification(message, type = 'success') {
        const notification = document.createElement('div');
        notification.className = `notification ${type}`;
        notification.textContent = message;
        
        document.body.appendChild(notification);
        
        setTimeout(() => {
            notification.remove();
        }, 3000);
    }

    // Karakter sayısını güncelleme yardımcı fonksiyonu
    function updateCharCount() {
        charCount.textContent = `${inputText.value.length}/5000`;
    }

 
});