document.addEventListener("DOMContentLoaded", function () {
    const input = document.getElementById("dataInput");
    const button = document.getElementById("updateButton");
    const chart = document.getElementById("chart");
    const svgWidth = 500, svgHeight = 300, barHeight = 30;
    
    const colorPalette = ["#ff5733", "#33ff57", "#3357ff", "#f0e68c", "#ff69b4"];
    
    const svg = d3.select("#chart")
        .append("svg")
        .attr("width", svgWidth)
        .attr("height", svgHeight);

    button.addEventListener("click", function () {
        let values = input.value.split(",").map(num => parseInt(num.trim())).filter(num => !isNaN(num));
        
        if (values.length === 0) {
            alert("Por favor, ingrese números enteros separados por coma.");
            return;
        }
        
        updateChart(values);
    });
    
    function updateChart(data) {
        const maxVal = d3.max(data);
        const xScale = d3.scaleLinear()
            .domain([0, maxVal])
            .range([0, svgWidth - 50]);

        svg.attr("height", data.length * (barHeight + 5));
        
        svg.selectAll("g").remove();

        const bars = svg.selectAll("g")
            .data(data)
            .enter()
            .append("g")
            .attr("transform", (d, i) => `translate(0, ${i * (barHeight + 5)})`);

        bars.append("rect")
            .attr("width", d => xScale(d))
            .attr("height", barHeight)
            .attr("fill", (d, i) => colorPalette[i % colorPalette.length]);

        bars.append("text")
            .attr("x", d => xScale(d) - 5)
            .attr("y", barHeight / 2)
            .attr("dy", "0.35em")
            .attr("fill", "white")
            .attr("text-anchor", "end")
            .text(d => d);
    }
});
