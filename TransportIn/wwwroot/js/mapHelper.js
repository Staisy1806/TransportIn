window.leafletMapFunctions = {
    map: null,
    markersLayer: null,

    initMap: function (elementId, lat, lng, zoom) {
        if (this.map) {
            this.map.remove();
        }

        this.map = L.map(elementId).setView([lat, lng], zoom);

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            maxZoom: 19,
            attribution: '© OpenStreetMap contributors'
        }).addTo(this.map);

        // Создаем специальный слой для маркеров, чтобы легко ими управлять
        this.markersLayer = L.layerGroup().addTo(this.map);
    },

    updateMarkers: function (items) {
        if (!this.map || !this.markersLayer) return;

        // Очищаем старые маркеры перед отрисовкой отфильтрованных
        this.markersLayer.clearLayers();

        // Добавляем новые маркеры из отфильтрованного списка
        items.forEach(item => {
            let popupContent = `<b>${item.name}</b><br/>Тип: <b>${item.type}</b><br/>Статус: ${item.status}`;
            var marker = L.marker([item.lat, item.lng]).bindPopup(popupContent);
            this.markersLayer.addLayer(marker);
        });
    }
};