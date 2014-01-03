/*Set the IFrame adapt the document's height.*/
function autoIframe(frameId) {
    frame = document.getElementById(frameId);
    innerDoc = (frame.contentDocument) ? frame.contentDocument : frame.contentWindow.document;
    frame.height = innerDoc.body.scrollHeight;
}
