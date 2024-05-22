function updateProgressBar(progressBar, progress) {
    switch (progress) {
        case 'None':
            progressBar.style.width = '0%';
            break;
        case 'Poz1':
            progressBar.style.width = '33%';
            break;
        case 'Poz2':
            progressBar.style.width = '66%';
            break;
        case 'Poz3':
            progressBar.style.width = '100%';
            break;
    }
}

function moveProgress(leadId) {
    const progressBar = document.getElementById('progress-' + leadId);
    let currentProgress = progressBar.dataset.progress;

    switch (currentProgress) {
        case 'None':
            currentProgress = 'Poz1';
            break;
        case 'Poz1':
            currentProgress = 'Poz2';
            break;
        case 'Poz2':
            currentProgress = 'Poz3';
            break;
        case 'Poz3':
            return; // Already at max progress
    }

    console.log("CURRENT PROGRESS", currentProgress)
    progressBar.dataset.progress = currentProgress;
    updateProgressBar(progressBar, currentProgress);

    fetch(`/Lead/${leadId}/UpdateProgress?progress=${currentProgress}`, {
        method: 'POST'
    }).then(response => {
        if (!response.ok) {
            console.error('Failed to update progress');
        }
    });
}

// On page load, ensure all progress bars are correctly initialized
document.addEventListener('DOMContentLoaded', () => {
    document.querySelectorAll('.progress').forEach(progressBar => {
        const progress = progressBar.dataset.progress;
        updateProgressBar(progressBar, progress);
    });
});

function removeProgress(leadId) {
    const progressBar = document.getElementById('progress-' + leadId);
    let currentProgress = progressBar.dataset.progress;

    switch (currentProgress) {
        case 'Poz3':
            currentProgress = 'Poz2';
            break;
        case 'Poz2':
            currentProgress = 'Poz1';
            break;
        case 'Poz1':
            currentProgress = 'None';
            break;
        case 'None':
            return; // Already at min progress
    }

    progressBar.dataset.progress = currentProgress;
    updateProgressBar(progressBar, currentProgress);

    fetch(`/Lead/${leadId}/UpdateProgress?progress=${currentProgress}`, {
        method: 'POST'
    }).then(response => {
        if (!response.ok) {
            console.error('Failed to update progress');
        }
    });
}