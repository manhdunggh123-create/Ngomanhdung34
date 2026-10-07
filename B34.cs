#include <stdio.h>
#include <string.h>

struct NhanVien {
    int maNV;
    char hoTen[50];
    char ngaySinh[15];
    float luong;
};

void nhapNhanVien(NhanVien &nv) {
    printf("Ma nhan vien: ");
    scanf("%d", &nv.maNV);
    getchar();

    printf("Ho ten: ");
    fgets(nv.hoTen, sizeof(nv.hoTen), stdin);
    nv.hoTen[strcspn(nv.hoTen, "\n")] = '\0';

    printf("Ngay sinh (dd/mm/yyyy): ");
    fgets(nv.ngaySinh, sizeof(nv.ngaySinh), stdin);
    nv.ngaySinh[strcspn(nv.ngaySinh, "\n")] = '\0';

    printf("Luong (trieu dong): ");
    scanf("%f", &nv.luong);
}

void nhapMang(NhanVien a[], int n) {
    for (int i = 0; i < n; i++) {
        printf("\nNhap nhan vien thu %d:\n", i + 1);
        nhapNhanVien(a[i]);
    }
}

void xuatNhanVien(NhanVien nv) {
    printf("%-10d %-25s %-15s %.2f\n",
           nv.maNV, nv.hoTen, nv.ngaySinh, nv.luong);
}

void xuatMang(NhanVien a[], int n) {
    printf("\n%-10s %-25s %-15s %s\n",
           "Ma NV", "Ho ten", "Ngay sinh", "Luong");
    for (int i = 0; i < n; i++) {
        xuatNhanVien(a[i]);
    }
}

void bubbleSort(NhanVien a[], int n) {
    for (int i = 0; i < n - 1; i++) {
        for (int j = 0; j < n - 1 - i; j++) {
            if (a[j].luong > a[j + 1].luong) {
                NhanVien temp = a[j];
                a[j] = a[j + 1];
                a[j + 1] = temp;
            }
        }
    }
}

void timKiemNhiPhan(NhanVien a[], int n, float x) {
    int left = 0;
    int right = n - 1;
    int found = 0;

    while (left <= right) {
        int mid = (left + right) / 2;

        if (a[mid].luong == x) {
            int i = mid;

            while (i >= 0 && a[i].luong == x) {
                i--;
            }

            i++;

            while (i < n && a[i].luong == x) {
                if (!found) {
                    printf("\nCac nhan vien co luong bang %.2f trieu dong:\n", x);
                    printf("%-10s %-25s %-15s %s\n",
                           "Ma NV", "Ho ten", "Ngay sinh", "Luong");
                }

                xuatNhanVien(a[i]);
                found = 1;
                i++;
            }

            break;
        }
        else if (a[mid].luong < x) {
            left = mid + 1;
        }
        else {
            right = mid - 1;
        }
    }

    if (!found) {
        printf("\nKhong tim thay nhan vien co luong bang %.2f trieu dong.\n", x);
    }
}

int main() {
    NhanVien a[100];
    int n;
    float x;

    do {
        printf("Nhap so luong nhan vien n = ");
        scanf("%d", &n);
    } while (n <= 0);

    nhapMang(a, n);

    printf("\nDANH SACH NHAN VIEN VUA NHAP");
    xuatMang(a, n);

    bubbleSort(a, n);

    printf("\nDANH SACH NHAN VIEN SAU KHI SAP XEP TANG DAN THEO LUONG");
    xuatMang(a, n);

    printf("\nNhap luong X can tim: ");
    scanf("%f", &x);

    timKiemNhiPhan(a, n, x);

    return 0;
}
