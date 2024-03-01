export function load_map(raw) {
    
    let map = L.map('map').locate({ setView: true, maxZoom: 16 });
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 19 }).addTo(map);

    const customMarker = L.Marker.extend({
        options: {
            title: 'title',
            description: 'description',
            eventAt: new Date().toJSON(),
            timeZone: 0
        }
    });
    for (var geojson_item of raw)
    {
        var marker = new customMarker(
            [geojson_item.longtitude,
                geojson_item.latitude],
            {
                opacity: 0.01,
                title: geojson_item.title,
                description: geojson_item.description,
                eventAt: geojson_item.eventAt,
                timeZone: geojson_item.timeZone
            }
        );

        marker.bindTooltip(geojson_item.title,
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