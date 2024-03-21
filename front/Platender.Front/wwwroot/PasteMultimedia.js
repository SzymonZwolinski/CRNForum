Blazor.registerCustomEventType("pastemultimedia", {
    browserEventName: 'paste',
    createEventArgs: event => {
        let isMultimedia = false;

        let data = event.clipboardData.getData('text');

        const items = event.clipboardData.items;

        const acceptedMediaTypes = ['image/png', 'image/jpg', 'image/jpeg'];

        for (let i = 0; i < items.length; i++) {
            const file = items[i].getAsFile();

            if (!file) {
                continue;
            }

            if (acceptedMediaTypes.indexOf(items[i].type) === -1) {
                continue;
            }

            isMultimedia = true;
            const url = window.URL || window.webkitURL;
            data = url.createObjectURL(file);
         }

        return {
            isMultimedia,
            data            
        }
    }
})
