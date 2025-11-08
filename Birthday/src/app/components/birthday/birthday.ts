import { Component, ChangeDetectionStrategy, HostListener } from '@angular/core';
import { trigger, style, transition, animate, stagger, query } from '@angular/animations';
import { IPhoto as Photo } from '../../models/iphoto';
import { IVideo as Video } from '../../models/ivideo';
import { CommonModule } from '@angular/common';
import confetti from 'canvas-confetti';
@Component({
  selector: 'app-birthday',
  templateUrl: './birthday.html',
  styleUrls: ['./birthday.scss'],
  imports: [CommonModule],
changeDetection: ChangeDetectionStrategy.OnPush,
  animations: [
    trigger('fadeInUp', [
      transition(':enter', [
        query('.photo-card, .video-card', [
          style({ opacity: 0, transform: 'translateY(30px)' }),
          stagger(100, [
            animate('600ms ease-out', style({ opacity: 1, transform: 'translateY(0)' }))
          ])
        ], { optional: true })
      ])
    ])
  ]
})
export class Birthday {
  friendName = 'Samuel';
  
  photos: Photo[] = [
    {
      src: 'photo1.jpeg',
      alt: 'Birthday memory 1',
      caption: 'Remember this amazing day? 🎉'
    },
    {
      src: 'photo2.jpeg',
      alt: 'Birthday memory 2',
      caption: 'Best times with you! ✨'
    },
    {
      src: 'photo3.jpeg',
      alt: 'Birthday memory 3',
      caption: 'Laughing together is the best 😄'
    },
    {
      src: 'photo4.jpeg',
      alt: 'Birthday memory 4',
      caption: 'Adventures await! 🌟'
    },
    {
      src: 'photo5.jpeg',
      alt: 'Birthday memory 5',
      caption: 'Making memories forever 💕'
    },
    {
      src: 'photo6.jpeg',
      alt: 'Birthday memory 6',
      caption: 'Here\'s to another year! 🎂'
    }
  ];

  video: Video = {
    src: 'Video.mp4',
    title: 'Special Birthday Message',
    description: 'A heartfelt message just for you! 💝',
    thumbnail: 'assets/images/video-thumbnail.jpg' // Optional: poster image
  };
  selectedPhoto: Photo | null = null;
  selectedIndex = -1;
  isConfettiActive = false;

  openLightbox(photo: Photo, index: number): void {
    this.selectedPhoto = photo;
    this.selectedIndex = index;
    document.body.style.overflow = 'hidden';
  }

  closeLightbox(): void {
    this.selectedPhoto = null;
    this.selectedIndex = -1;
    document.body.style.overflow = 'auto';
  }

  navigatePhoto(direction: 'prev' | 'next'): void {
    if (direction === 'prev') {
      this.selectedIndex = this.selectedIndex > 0 ? this.selectedIndex - 1 : this.photos.length - 1;
    } else {
      this.selectedIndex = this.selectedIndex < this.photos.length - 1 ? this.selectedIndex + 1 : 0;
    }
    this.selectedPhoto = this.photos[this.selectedIndex];
  }

  @HostListener('document:keydown', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent): void {
    if (this.selectedPhoto) {
      switch (event.key) {
        case 'Escape':
          this.closeLightbox();
          break;
        case 'ArrowLeft':
          this.navigatePhoto('prev');
          break;
        case 'ArrowRight':
          this.navigatePhoto('next');
          break;
      }
    }
  }

  triggerSurprise(): void {
    this.isConfettiActive = true;
    this.createConfetti();
    this.launchFireworks();
    
    // Play audio
    const audio = new Audio('Cheer.m4a');
    audio.play().catch(err => console.log('Audio playback failed:', err));
    
    // Reset confetti after animation
    setTimeout(() => {
      this.isConfettiActive = false;
    }, 4000);
  }

  private createConfetti(): void {
    const confettiContainer = document.querySelector('.confetti-container');
    if (!confettiContainer) return;

    const colors = ['#ff6b9d', '#feca57', '#48dbfb', '#ff9ff3', '#54a0ff', '#00d2d3'];
    const confettiCount = 150;

    for (let i = 0; i < confettiCount; i++) {
      const confetti = document.createElement('div');
      confetti.className = 'confetti-piece';
      confetti.style.left = Math.random() * 100 + '%';
      confetti.style.backgroundColor = colors[Math.floor(Math.random() * colors.length)];
      confetti.style.animationDelay = Math.random() * 3 + 's';
      confetti.style.animationDuration = (Math.random() * 3 + 2) + 's';
      confettiContainer.appendChild(confetti);

      setTimeout(() => confetti.remove(), 6000);
    }
  }
    private launchFireworks(): void {
    const duration = 3 * 1000;
    const end = Date.now() + duration;

    (function frame() {
      confetti({
        particleCount: 8,
        startVelocity: 40,
        spread: 360,
        ticks: 60,
        origin: {
          x: Math.random(),
          y: Math.random() * 0.5 // fireworks
        },
        colors: ['#ff6b6b', '#feca57', '#1dd1a1', '#54a0ff', '#ff9ff3']
      });

      if (Date.now() < end) {
        requestAnimationFrame(frame);
      }
    })();
  }
}