function DatetimePicker() {
    return {
        restrict: 'A',
        require: '?ngModel',
        link: function (scope, element, attrs, ngModelController) {
            var datepickerFormat = 'dd/mm/yyyy',
                momentFormat = 'dd/mm/yyyy',
                datepicker,
                elPicker;
            datepicker = element.datepicker({
                autoclose: true,
                keyboardNavigation: false,
                todayHighlight: true,
                format: datepickerFormat
            });
            elPicker = datepicker.data('datepicker').picker;
            datepicker.on('show', function (evt) {
                elPicker.css('left', parseInt(elPicker.css('left')) + +attrs.offsetX);
                elPicker.css('top', parseInt(elPicker.css('top')) + +attrs.offsetY);
            });
        }
    };
}
function NumbersOnly() {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, ngModelCtrl) {
            function fromUser(text) {
                if (text) {
                    var transformedInput = text.replace(/[^0-9]/g, '');
                    if (transformedInput !== text) {
                        ngModelCtrl.$setViewValue(transformedInput);
                        ngModelCtrl.$render();
                    }
                    return transformedInput;
                }
                return undefined;
            }
            ngModelCtrl.$parsers.push(fromUser);
        }
    };
}
function DecimalOnly() {
    return {
        require: '?ngModel',
        link: function (scope, element, attrs, ngModelCtrl) {
            if (!ngModelCtrl) {
                return;
            }
            ngModelCtrl.$parsers.push(function (val) {
                if (angular.isUndefined(val)) {
                    var val = '';
                }
                var clean = val.replace(/[^0-9\.]/g, '');
                var decimalCheck = clean.split('.');
                if (!angular.isUndefined(decimalCheck[1])) {
                    decimalCheck[1] = decimalCheck[1].slice(0, 3);
                    clean = decimalCheck[0] + '.' + decimalCheck[1];
                }
                if (val !== clean) {
                    ngModelCtrl.$setViewValue(clean);
                    ngModelCtrl.$render();
                }
                return clean;
            });
            element.bind('keypress', function (event) {
                if (event.keyCode === 32) {
                    event.preventDefault();
                }
            });
        }
    };
}