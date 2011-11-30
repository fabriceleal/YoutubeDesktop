var result = eval(object);


ret = []
for (var index in result["feed"]["entry"]) {
    var value = result["feed"]["entry"][index];
    ret.push(value)
}