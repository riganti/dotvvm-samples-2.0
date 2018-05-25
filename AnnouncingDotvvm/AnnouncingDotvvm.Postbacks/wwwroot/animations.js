dotvvm.events.beforePostback.subscribe(function() {

    // increment index
    var vm = dotvvm.viewModels.root.viewModel;
    vm.Index(vm.Index() + 1);

    // send cargo
    var car = document.createElement("div");
    car.innerText = vm.Index();
    car.className = "cargo moving";
    car.style.left = 0;
    document.querySelector(".canvas").appendChild(car);

    // start car movement
    var step = 0;
    var interval = window.setInterval(function() {
        car.style.left = (step * 2) + "px";
        step++;

        if (step > 150) {
            car.remove();
            window.clearInterval(interval);
        }
    }, 20);

});