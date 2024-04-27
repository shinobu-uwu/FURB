def direction(p1, p2, p3):
    return (p2[0]-p1[0])*(p3[1]-p1[1]) - (p2[1] - p1[1]) * (p3[0] - p1[0])


def is_left_turn(p1, p2, p3):
    return direction(p1, p2, p3) > 0


def graham_scan(points: list) -> list:
    points.sort(key=lambda p: (p[0], p[1]))
    l_sup = [points[0], points[1]]
    l_inf = []
    for i in range(2, len(points)):
        l_sup.append(points[i])
        while len(l_sup) > 2 and not is_left_turn(l_sup[-3], l_sup[-2], l_sup[-1]):
            l_sup.pop(-2)
    l_inf.append(points[-1])
    l_inf.append(points[-2])
    for i in range(len(points) - 3, -1, -1):
        l_inf.append(points[i])
        while len(l_inf) > 2 and not is_left_turn(l_inf[-3], l_inf[-2], l_inf[-1]):
            l_inf.pop(-2)
    l_inf.pop(0)
    l_inf.pop(-1)
    l_sup.pop(0)
    l_sup.pop(-1)

    return l_sup + l_inf


def is_inside_convex_hull(convex_hull: list, p: tuple) -> bool:
    for i in range(len(convex_hull)):
        if not is_left_turn(convex_hull[i], convex_hull[(i + 1) % len(convex_hull)], p):
            return False
    return True


def has_critical_point(points: list) -> bool:
    convex_hull = graham_scan(points)
    for p in points:
        if not is_inside_convex_hull(convex_hull, p):
            return True
    return False


while True:
    n = int(input())
    if n == 0:
        break
    points = [tuple(map(int, input().split())) for _ in range(n)]
    print('Yes' if has_critical_point(points) else 'No')
