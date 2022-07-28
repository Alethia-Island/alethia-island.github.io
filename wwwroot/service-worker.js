// In development, always fetch from the network and do not enable offline support.
// This is because caching would make development more difficult (changes would not
// be reflected on the first load after each change).
self.addEventListener('fetch', () => { });

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
];

const cacheName = 'app_cache';

self.addEventListener('install', function (e) {
    e.waitUntil(
        caches.open(cacheName).then(function (cache) {
            return cache.addAll(filesToCache);
        })
    );
});

self.addEventListener('activate', event => {
    event.waitUntil(self.clients.claim());
});

self.addEventListener('fetch', function(event) {
  event.respondWith(
    caches.open(cacheName).then(function(cache) {
      return cache.match(event.request).then(function (response) {
        return response || fetch(event.request).then(function(response) {
          return response;
        });
      });
    })
  );
});

const registration = navigator.serviceWorker;

if (registration) { // if there is a SW active
    registration.addEventListener('updatefound', () => {
        console.log('Service Worker update detected!');
    });
}