window.convertToBlob = function (fileName, base64Data) {
    const byteCharacters = atob(base64Data);
    const byteNumbers = new Array(byteCharacters.length);
    
    for (let i = 0; i < byteCharacters.length; i++) {
        byteNumbers[i] = byteCharacters.charCodeAt(i);
    }

    const byteArray = new Uint8Array(byteNumbers);
    const blob = new Blob([byteArray], { type: 'application/octet-stream' });
    
    const url = window.URL || window.webkitURL;
    const blobUrl = url.createObjectURL(blob);

    return blobUrl;
}

window.releaseBlobUrl = function (url) {    
    const revokeUrl = window.URL || window.webkitURL;
    revokeUrl.revokeObjectURL(url);
}
