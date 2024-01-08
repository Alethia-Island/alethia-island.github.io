// Caution! Be sure you understand the caveats before publishing an application with
// offline support. See https://aka.ms/blazor-offline-considerations

self.importScripts('./service-worker-assets.js');
self.addEventListener('install', event => event.waitUntil(onInstall(event)));
self.addEventListener('activate', event => event.waitUntil(onActivate(event)));
self.addEventListener('fetch', event => event.respondWith(onFetch(event)));

const cacheNamePrefix = 'app-cache-';
const cacheName = `${cacheNamePrefix}${self.assetsManifest.version}`;

const github_images = 'https://raw.githubusercontent.com/Alethia-Island/assets/master/images/sandbox/';
const github_pages = 'https://raw.githubusercontent.com/Alethia-Island/WebLinks/main/';

const filesToCache = [
    `${github_images}backgrounds/river_and_stones.png`,
    `${github_images}help-point-sign.jpg`,
    `${github_images}icons/icon-512.png`,
    `${github_images}object-return.jpg`,
    `${github_images}unpacking-areas.jpg`,

    `${github_pages}contact_us.md`,
    `${github_pages}general_information.md`,
    `${github_pages}help_points.md`,
    `${github_pages}index.md`,
    `${github_pages}links.md`,
    `${github_pages}object-return-service.md`,
    `${github_pages}privacy_areas.md`,
    `${github_pages}sandbox_rules.md`,
    `${github_pages}script-limits.md`
];

async function onInstall(event) {
    await caches.open(cacheName).then(cache => cache.addAll(filesToCache));
}

async function onActivate(event) {
    const cacheKeys = await caches.keys();
    await Promise.all(cacheKeys
        .filter(key => key.startsWith(cacheNamePrefix) && key !== cacheName)
        .map(key => caches.delete(key)));
}

async function onFetch(event) {
    let cachedResponse = null;
    if (event.request.method === 'GET') {
        const shouldServeIndexHtml = event.request.mode === 'navigate';

        const request = shouldServeIndexHtml ? 'index.html' : event.request;
        const cache = await caches.open(cacheName);
        cachedResponse = await cache.match(request);
    }

    return cachedResponse || fetch(event.request);
}
/* Manifest version: 5GtcBCd/ */
