from moviepy.video.io.VideoFileClip import VideoFileClip
import os


def genvideos(src: str, amount: int):
    """
    src stands for source of video\n
    amount is represents the count of splitten videos
    """
    print("*"*25)
    print("\tVIDEO SPLIT TOOL\t")

    if amount <= 0:
        print("no cuts possible")
        return

    video_clip = VideoFileClip(src)
    duration = video_clip.duration
    limit = duration/amount
    start = 0
    videoExtension = src[src.rindex("."):]

    print("source :", src)
    print("duration :", duration)
    print("extension :", videoExtension)
    print("*"*25)
    for i in range(amount):
        end = duration if i+1 >= amount else (i+1)*limit

        print(i+1, ">", start, ":", end)

        cut = video_clip.subclip(start, end)

        if not os.path.exists("./outputs/"):
            os.mkdir("outputs")
        print("*"*25)
        print("Cutting : {0}th video".format(i+1)+videoExtension)

        cut.write_videofile("outputs/{0}th video".format(i+1)+videoExtension)

        start += limit

        print("Cut Completed : {0}th video".format(i+1)+videoExtension)

    video_clip.close()
    print("Video seperation ended")


girdi_video = "C:/Users/Computer/Videos/SnakeGame.mp4"
try:
    genvideos(girdi_video, 6)
except Exception as e:
    print(e)
