
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
    const translateBtn = document.querySelector('.translate-button');
    const charCount = document.querySelector('.char-count');
    const clearTextBtn = document.querySelector('.clear-text');
    const copyTextBtn = document.querySelector('.copy-text');
    const clearHistoryBtn = document.querySelector('.clear-history');
    const historyList = document.querySelector('.history-list');

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

    // Metni temizleme
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

    // Çeviri geçmişini yerel depolamadan yükleme
    function loadHistory() {
        const history = JSON.parse(localStorage.getItem('translationHistory')) || [];
        historyList.innerHTML = '';
        
        history.forEach(item => {
            const li = document.createElement('li');
            li.innerHTML = `
                <div class="history-item">
                    <div class="translation-pair">
                        <p class="original-text">${item.from}: ${item.originalText}</p>
                        <p class="translated-text">${item.to}: ${item.translatedText}</p>
                    </div>
                    <div class="history-actions">
                        <button class="reuse-translation">Tekrar Kullan</button>
                        <button class="delete-translation">Sil</button>
                    </div>
                </div>
            `;
            historyList.appendChild(li);
        });
    }

    // Çeviri geçmişine ekleme
    function addToHistory(originalText, translatedText, from, to) {
        const history = JSON.parse(localStorage.getItem('translationHistory')) || [];
        history.unshift({ originalText, translatedText, from, to, date: new Date() });
        
        // Maksimum 10 kayıt tutma
        if (history.length > 10) {
            history.pop();
        }
        
        localStorage.setItem('translationHistory', JSON.stringify(history));
        loadHistory();
    }

    // Çeviri geçmişini temizleme
    clearHistoryBtn.addEventListener('click', () => {
        localStorage.removeItem('translationHistory');
        loadHistory();
        showNotification('Çeviri geçmişi temizlendi!');
    });

    // Çeviri işlemi
    translateBtn.addEventListener('click', async () => {
        if (!inputText.value.trim()) {
            showNotification('Lütfen çevrilecek metin girin!', 'error');
            return;
        }

        try {
            // Çeviri Kodu Gelicek
            // Şimdilik Aynısını Yazıcak
            const translatedText = `Translated: ${inputText.value}`;
            outputText.value = translatedText;
            
            addToHistory(
                inputText.value,
                translatedText,
                fromLang.value,
                toLang.value
            );
            
            showNotification('Çeviri tamamlandı!');
        } catch (error) {
            showNotification('Çeviri sırasında bir hata oluştu!', 'error');
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

    // Sayfa yüklendiğinde geçmişi yükle
    loadHistory();

    historyList.addEventListener('click', (e) => {
        const historyItem = e.target.closest('.history-item');
        if (!historyItem) return;

        if (e.target.classList.contains('reuse-translation')) {
            const originalText = historyItem.querySelector('.original-text').textContent.split(': ')[1];
            const translatedText = historyItem.querySelector('.translated-text').textContent.split(': ')[1];
            
            inputText.value = originalText;
            outputText.value = translatedText;
            updateCharCount();
        }

        if (e.target.classList.contains('delete-translation')) {
            const history = JSON.parse(localStorage.getItem('translationHistory'));
            const itemIndex = Array.from(historyList.children).indexOf(historyItem.parentElement);
            
            history.splice(itemIndex, 1);
            localStorage.setItem('translationHistory', JSON.stringify(history));
            loadHistory();
        }
    });
});