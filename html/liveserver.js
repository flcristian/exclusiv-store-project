const browserSync = require('browser-sync').create();
const fg = require('fast-glob');

const repositoryPath = process.cwd();

// Initialize BrowserSync
let init = browserSync.init({
    "server": repositoryPath,
    "files": repositoryPath,
    "logLevel": 'silent',
    "notify": false,
});

// Watch for new subdirectories
fg(`${repositoryPath}/**/`, { onlyDirectories: true }).then((directories) => {
    directories.forEach((directory) => {
        browserSync.watch(directory, { ignoreInitial: true }).on('all', () => {
            // Trigger the reload event when a file change occurs in a subdirectory
            browserSync.reload();
        });
    });
});