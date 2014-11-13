(function () {
    var editor = CodeMirror.fromTextArea($("#fileContent")[0], {
                                             styleActiveLine: true,
                                             lineNumbers: true,
                                             lineWrapping: true,
                                             autoCloseBrackets: true
                                         });
    editor.setOption("theme", "mdn-like");
})();