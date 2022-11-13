function InitializeEditableEventListener() {
    document.addEventListener("input", onInput);
    console.log("listener mounted");
    function onInput(e) {
        let target = e.target;
        console.log(target.localName);
        console.log("not fix");
        if (target.localName === 'p') {
            //if (!target.value && !target.__contenteditable) target.__contenteditable = true;
            target.value = target.innerText;
            e.Value = target.value
            console.log(target.value)
            console.log(e)
        }
    }
}