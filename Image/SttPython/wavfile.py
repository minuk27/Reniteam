import os
import time
import pyaudio
import wave
import keyboard


def record_audio(file_name, record_seconds=5, chunk=1024, format=pyaudio.paInt16, channels=1, rate=44100):
    audio = pyaudio.PyAudio()

    # Open a new stream for recording
    stream = audio.open(format=format,
                        channels=channels,
                        rate=rate,
                        input=True,
                        frames_per_buffer=chunk)

    print("Recording...")

    frames = []

    # Record audio data in chunks
    start_time = time.time()
    while time.time() - start_time < record_seconds:
        data = stream.read(chunk)
        frames.append(data)
        if keyboard.is_pressed("1"):
            break

    # Stop and close the stream
    stream.stop_stream()
    stream.close()
    audio.terminate()

    # Save the recorded audio to a WAV file
    with wave.open(file_name, 'wb') as wf:
        wf.setnchannels(channels)
        wf.setsampwidth(audio.get_sample_size(format))
        wf.setframerate(rate)
        wf.writeframes(b''.join(frames))

    print(f"Audio saved as {file_name}")

if __name__ == "__main__":
    # 사용자의 홈 디렉토리 경로 가져오기
    home_dir = os.path.expanduser("./Assets/8.Data")

    # 파일 이름 및 경로 설정
    file_name = os.path.join(home_dir, "recorded_audio.wav")

    # 녹음 함수 호출
    record_seconds = 8  # 실행 시간
    record_audio(file_name, record_seconds)
