document.addEventListener('DOMContentLoaded', () => {
    const currentPath = window.location.pathname.toLowerCase();

    document.querySelectorAll('.nav-link').forEach((link) => {
        const href = link.getAttribute('href')?.toLowerCase() || '';
        if (href && currentPath.includes(href.replace('/', '')) && href !== '/') {
            link.classList.add('active');
        } else if (href === '/' && (currentPath === '/' || currentPath.endsWith('/home') || currentPath.endsWith('/home/index'))) {
            link.classList.add('active');
        }
    });
});
