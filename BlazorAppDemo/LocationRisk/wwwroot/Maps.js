window.initMap = function () {
    var map = L.map('mapId').setView([50.279133, 18.685578], 13);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    window.map = map;
};

window.updateMap = function (lat, lon) {
    var map = window.map;
    if (map) {
        map.setView([lat, lon], 13);
        if (window.marker) {
            map.removeLayer(window.marker);
        }
        window.marker = L.marker([lat, lon]).addTo(map);
    }
};