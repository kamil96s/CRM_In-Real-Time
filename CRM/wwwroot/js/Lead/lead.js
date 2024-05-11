let currentProgress = 0;

function moveProgress() {
    const progressBar = document.querySelector('.progress');
    const steps = 100 / 3;  // Liczba krok�w (3 kroki pomi�dzy 4 etapami)
    currentProgress += steps;
    if (currentProgress > 100) currentProgress = 100; // Zapobieganie przekroczeniu
    progressBar.style.width = currentProgress + '%';
}
