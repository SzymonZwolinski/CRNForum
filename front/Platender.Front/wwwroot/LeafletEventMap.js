export function load_map(raw) {
    
    let map = L.map('map').locate({ setView: true, maxZoom: 16 });
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 19 }).addTo(map);

    var geojson_layer = L.geoJSON().addTo(map);
    var geojson_data = JSON.parse(String(raw));
    const customMarker = L.Marker.extend({
        options: {
            title: 'title',
            description: 'description'
        }
    });

    for (var geojson_item of geojson_data) {

        geojson_layer.addData(geojson_item);
        var marker = new customMarker(
            [geojson_item.geometry.coordinates[1],
            geojson_item.geometry.coordinates[0]],
            {
                opacity: 0.01,
                title: 'test',
                description: 'test'

            }
        );
        marker.bindTooltip(geojson_item.properties.name,
            {
                permanent: true,
                className: "my-label",
                offset: [0, 0]
            }
        );
        marker.addTo(map);
        marker.on('click', onMarkerClick);
    };
}

function onMarkerClick(e) {
    alert("You clicked the map at " + e.latlng);
    console.log(e);
}