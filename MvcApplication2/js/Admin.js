
        const menuItems = document.querySelectorAll("#menu li");
const contentContainers = {
    sach: document.getElementById("sach-list"),
    tacgia: document.getElementById("tacgia-list"),
    nxb: document.getElementById("nxb-list"),
    theloai: document.getElementById("theloai-list"),
    khachhang: document.getElementById("khachhang-list"),
    nhanvien: document.getElementById("nhanvien-list"),
};

menuItems.forEach(item => {
    item.addEventListener("click", () => {
        const target = item.getAttribute("data-target");
const title = item.textContent;
document.getElementById("page-title").textContent = `Danh Sách ${title}`;

// Hiển thị nội dung tương ứng và ẩn các nội dung khác
for (const key in contentContainers) {
    if (key === target) {
        contentContainers[key].style.display = "table";
    } else {
        contentContainers[key].style.display = "none";
    }
}
});
});
