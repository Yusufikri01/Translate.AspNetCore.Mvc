// Gece Modu
const toggleButton = document.querySelector('.toggle-mode');
toggleButton.addEventListener('click', () => {
    document.body.classList.toggle('dark-mode');
});
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


// Dil Değiştirme
const langButtons = document.querySelectorAll('.lang-switch');
langButtons.forEach(button => {
    button.addEventListener('click', () => {
        const selectedLang = button.getAttribute('data-lang');
        alert(`Dil ${selectedLang} olarak seçildi.`);
    });
});

// Otomatik Temizleme
const inputText = document.querySelector('.input-text');
inputText.addEventListener('focus', () => {
    inputText.value = '';
});

// Kopyala Butonu
const copyButton = document.querySelector('.copy-button');
const outputText = document.querySelector('.output-text');

copyButton.addEventListener('click', () => {
    outputText.select();
    document.execCommand('copy');
    alert('Çeviri kopyalandı!');
});

// Çeviri Yapma ve Geçmişe Ekleme
const translateButton = document.querySelector('.translate-button');
const historyList = document.querySelector('.history-list');
const history = [];

translateButton.addEventListener('click', () => {
    const text = inputText.value;
    if (text) {
        outputText.value = text.split('').reverse().join('');  // Basit çeviri simülasyonu

        // Geçmişe ekleme
        const translation = { input: text, output: outputText.value };
        history.push(translation);
        const listItem = document.createElement('li');
        listItem.textContent = `${translation.input} → ${translation.output}`;
        historyList.appendChild(listItem);
    }
});
document.getElementById('kayıtButonu').addEventListener('click', function() {
    const kelime = document.getElementById('kelime').value;
    const karşılık = document.getElementById('karşılık').value;
    const kelimeListesi = document.getElementById('kelimeListesi');

    if (kelime && karşılık) {
        const li = document.createElement('li');
        li.textContent = `${kelime} - ${karşılık}`;
        kelimeListesi.appendChild(li);

        // Input alanlarını temizle
        document.getElementById('kelime').value = '';
        document.getElementById('karşılık').value = '';
    } else {
        alert('Lütfen hem kelimeyi hem de karşılığını girin.');
    }
});
