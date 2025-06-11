.03[Lesson4_Vector3向量](file:///D:/Obsidian%20Unity/Unity/Unity%E5%9B%9B%E9%83%A8%E6%9B%B2/Assets/Scripts/Unity%E5%9F%BA%E7%A1%80/3D%E6%95%B0%E5%AD%A6/Lesson4_Vector3%E5%90%91%E9%87%8F.cs)
# 1.向量模长和单位向量
单位向量=![[Pasted image 20241023142011.png]]

# 2.向量加减乘除

![[Pasted image 20240908130617.png]]
![[Pasted image 20240908130738.png]]![[Pasted image 20240908131222.png]]
![[Pasted image 20240908131305.png]]
![[Pasted image 20240908131616.png]]
![[Pasted image 20240908131928.png]]
![[Pasted image 20240908132105.png]]
![[Pasted image 20240908132324.png]]

# 3.向量的投影
1.基本概念
　　给定两个向量v和n，能将v分解成两个分量，一个是垂直于向量n,Va，一个平行于向量n,V||，平
行于向量n的向量V||我们称为在向量n上的投影。
![[Pasted image 20241023141450.png]]
2.投影的求解
　　因为向量n平行于投影向量，所以可以求出向量n的单位向量再乘以投影的模，就可以得到投影
向量，如下
![[Pasted image 20241023141503.png]]
　　我们接下来求投影的模即可，我们可以根据三角函数的余弦公式来求出投影的模
![[Pasted image 20241023141514.png]]
　　代入投影的模就可以求出投影向量
![[Pasted image 20241023141522.png]]
3.垂直向量的求解
　　根据三角形法则，可以轻易求出垂直的向量
![[Pasted image 20241023141530.png]]
　　
# 4.向量点乘
![[Pasted image 20240908133739.png]]  
![[Pasted image 20240908134031.png]]
![[Pasted image 20240908143835.png]]
# 5.向量叉乘
![[Pasted image 20240909151725.png]]
![[Pasted image 20240909152347.png]]
# 6.插值运算
![[Pasted image 20240909162650.png]]
![[Pasted image 20240909162707.png]]
![[Pasted image 20240909170802.png]]