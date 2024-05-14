// In your lead.js
function moveProgress(leadId) {
    const progressBar = document.getElementById('progress-' + leadId);
    // Za³ó¿my, ¿e currentProgress przechowuje obecny stan jako wartoœæ enum
    let currentProgress = progressBar.dataset.progress; // Nowe pole dataset, które trzyma aktualny enum

    switch (currentProgress) {
        case 'None':
            currentProgress = 'Poz1';
            progressBar.style.width = '33%';
            break;
        case 'Poz1':
            currentProgress = 'Poz2';
            progressBar.style.width = '66%';
            break;
        case 'Poz2':
            currentProgress = 'Poz3';
            progressBar.style.width = '100%';
            break;
        case 'Poz3':
            // Nic nie rób, jeœli ju¿ na maksymalnym postêpie
            break;
    }

    progressBar.dataset.progress = currentProgress; // Aktualizacja stanu na frontendzie

    // Send an AJAX request to update the progress in the database
    fetch(`/Lead/UpdateProgress?leadId=${leadId}&progress=${currentProgress}`, {
        method: 'POST'
    }).then(response => {
        if (!response.ok) {
            console.error('Failed to update progress');
        }
    });
}
function removeProgress(leadId) {
    const progressBar = document.getElementById('progress-' + leadId);
    // Za³ó¿my, ¿e currentProgress przechowuje obecny stan jako wartoœæ enum
    let currentProgress = progressBar.dataset.progress; // Nowe pole dataset, które trzyma aktualny enum

    switch (currentProgress) {
        case 'Poz3':
            currentProgress = 'Poz2';
            progressBar.style.width = '66%';
            break;
        case 'Poz2':
            currentProgress = 'Poz1';
            progressBar.style.width = '33%';
            break;
        case 'Poz1':
            currentProgress = 'None';
            progressBar.style.width = '0%';
            break;
        case 'None':
            // Nic nie rób, jeœli ju¿ na minimalnym postêpie
            break;
    }

    progressBar.dataset.progress = currentProgress; // Aktualizacja stanu na frontendzie

    // Send an AJAX request to update the progress in the database
    fetch(`/Lead/UpdateProgress?leadId=${leadId}&progress=${currentProgress}`, {
        method: 'POST'
    }).then(response => {
        if (!response.ok) {
            console.error('Failed to update progress');
        }
    });
}
